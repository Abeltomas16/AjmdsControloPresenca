namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afastamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacao = c.String(maxLength: 100, unicode: false),
                        DataAfasmento = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        Apurado = c.Boolean(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        FuncionarioId = c.Short(nullable: false),
                        SituacaoId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.Situacao", t => t.SituacaoId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.SituacaoId);
            
            CreateTable(
                "dbo.Situacao",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ST_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feriado",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "FD_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Afastamento", "SituacaoId", "dbo.Situacao");
            DropForeignKey("dbo.Afastamento", "FuncionarioId", "dbo.Funcionario");
            DropIndex("dbo.Afastamento", new[] { "SituacaoId" });
            DropIndex("dbo.Afastamento", new[] { "FuncionarioId" });
            DropTable("dbo.Feriado",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "FD_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Situacao",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "ST_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Afastamento");
        }
    }
}
