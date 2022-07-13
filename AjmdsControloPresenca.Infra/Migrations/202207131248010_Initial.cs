namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        CargoId = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        SobreNome = c.String(nullable: false, maxLength: 30, unicode: false),
                        SalarioLiquido = c.Decimal(nullable: false, storeType: "money"),
                        Observacao = c.String(maxLength: 200, unicode: false),
                        ContactoPrincipa = c.String(),
                        ContactoAuxiliar = c.String(nullable: false, maxLength: 50, unicode: false),
                        Estado = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        GeneroId = c.Short(nullable: false),
                        EstadoCivilId = c.Short(nullable: false),
                        DepartamentoId = c.Short(nullable: false),
                        CargoId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoCivil", t => t.EstadoCivilId, cascadeDelete: true)
                .ForeignKey("dbo.Genero", t => t.GeneroId, cascadeDelete: true)
                .Index(t => t.GeneroId)
                .Index(t => t.EstadoCivilId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.DepartamentoTurno",
                c => new
                    {
                        TurnoSegundaId = c.Short(nullable: false),
                        DepartamentoId = c.Short(nullable: false),
                        TurnoTercaId = c.Short(nullable: false),
                        TurnoQuartaId = c.Short(nullable: false),
                        TurnoQuintaId = c.Short(nullable: false),
                        TurnoSextaId = c.Short(nullable: false),
                        TurnoSabadoId = c.Short(nullable: false),
                        TurnoDomingoId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.Turno", t => t.TurnoDomingoId)
                .ForeignKey("dbo.Turno", t => t.TurnoQuartaId)
                .ForeignKey("dbo.Turno", t => t.TurnoQuintaId)
                .ForeignKey("dbo.Turno", t => t.TurnoSabadoId)
                .ForeignKey("dbo.Turno", t => t.TurnoSegundaId)
                .ForeignKey("dbo.Turno", t => t.TurnoSextaId)
                .ForeignKey("dbo.Turno", t => t.TurnoTercaId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .Index(t => t.TurnoSegundaId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.TurnoTercaId)
                .Index(t => t.TurnoQuartaId)
                .Index(t => t.TurnoQuintaId)
                .Index(t => t.TurnoSextaId)
                .Index(t => t.TurnoSabadoId)
                .Index(t => t.TurnoDomingoId);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Entrada = c.DateTime(nullable: false),
                        Saida = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        TurnoToleranciaAtraso = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstadoCivil",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 20,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 15,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_DESCRICAO",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presenca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Entrada = c.DateTime(nullable: false),
                        Saida = c.DateTime(nullable: false),
                        FuncionarioId = c.Short(nullable: false),
                        Funcionario_Id = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_Id)
                .Index(t => t.FuncionarioId)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        FuncionarioId = c.Short(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_NOME",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        Senha = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FuncionarioId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Presenca", "Funcionario_Id", "dbo.Funcionario");
            DropForeignKey("dbo.Presenca", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Funcionario", "EstadoCivilId", "dbo.EstadoCivil");
            DropForeignKey("dbo.Funcionario", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.DepartamentoTurno", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoTercaId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoSextaId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoSegundaId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoSabadoId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoQuintaId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoQuartaId", "dbo.Turno");
            DropForeignKey("dbo.DepartamentoTurno", "TurnoDomingoId", "dbo.Turno");
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropIndex("dbo.Usuario", new[] { "FuncionarioId" });
            DropIndex("dbo.Presenca", new[] { "Funcionario_Id" });
            DropIndex("dbo.Presenca", new[] { "FuncionarioId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoDomingoId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoSabadoId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoSextaId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoQuintaId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoQuartaId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoTercaId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "DepartamentoId" });
            DropIndex("dbo.DepartamentoTurno", new[] { "TurnoSegundaId" });
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "DepartamentoId" });
            DropIndex("dbo.Funcionario", new[] { "EstadoCivilId" });
            DropIndex("dbo.Funcionario", new[] { "GeneroId" });
            DropTable("dbo.Usuario",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Nome",
                        new Dictionary<string, object>
                        {
                            { "IX_NOME", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Presenca");
            DropTable("dbo.Genero",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "IX_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.EstadoCivil",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "IX_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Turno");
            DropTable("dbo.DepartamentoTurno");
            DropTable("dbo.Departamento",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "IX_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Funcionario");
            DropTable("dbo.Cargo",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Descricao",
                        new Dictionary<string, object>
                        {
                            { "IX_DESCRICAO", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
