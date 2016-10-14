namespace ManageCase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedTypesinRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseNumbers",
                c => new
                    {
                        caseId = c.Int(nullable: false, identity: true),
                        caseName = c.String(),
                        caseNumber = c.String(),
                    })
                .PrimaryKey(t => t.caseId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        departmentId = c.Int(nullable: false, identity: true),
                        departmentCode = c.String(),
                        departmentName = c.String(),
                    })
                .PrimaryKey(t => t.departmentId);
            
            CreateTable(
                "dbo.DocumentSources",
                c => new
                    {
                        sourceId = c.Int(nullable: false, identity: true),
                        sourceCode = c.String(),
                        sourceName = c.String(),
                    })
                .PrimaryKey(t => t.sourceId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        documentId = c.Int(nullable: false, identity: true),
                        documentCode = c.String(),
                        documentName = c.String(),
                    })
                .PrimaryKey(t => t.documentId);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        facilityId = c.Int(nullable: false, identity: true),
                        facilityName = c.String(),
                    })
                .PrimaryKey(t => t.facilityId);
            
            CreateTable(
                "dbo.InternalCaseNumbers",
                c => new
                    {
                        internalCaseId = c.Int(nullable: false, identity: true),
                        internalCaseNumber = c.Int(nullable: false),
                        caseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.internalCaseId)
                .ForeignKey("dbo.CaseNumbers", t => t.caseId, cascadeDelete: true)
                .Index(t => t.caseId);
            
            CreateTable(
                "dbo.Principals",
                c => new
                    {
                        principalId = c.Int(nullable: false, identity: true),
                        principalCode = c.String(),
                        principalFirstName = c.String(),
                        principalLastName = c.String(),
                    })
                .PrimaryKey(t => t.principalId);
            
            CreateTable(
                "dbo.PrincipalCaseNumberJunctions",
                c => new
                    {
                        principalCaseNumberJunctionId = c.Int(nullable: false, identity: true),
                        principalId = c.Int(nullable: false),
                        caseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.principalCaseNumberJunctionId)
                .ForeignKey("dbo.CaseNumbers", t => t.caseId, cascadeDelete: true)
                .ForeignKey("dbo.Principals", t => t.principalId, cascadeDelete: true)
                .Index(t => t.principalId)
                .Index(t => t.caseId);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        recordId = c.Int(nullable: false, identity: true),
                        internalCaseId = c.Int(nullable: false),
                        sourceId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        documentId = c.Int(nullable: false),
                        facilityId = c.Int(nullable: false),
                        recordReferenceNumber = c.String(),
                        pageNumber = c.String(),
                        recordEntryDate = c.DateTime(nullable: false),
                        providerFirstName = c.String(),
                        providerLastName = c.String(),
                        memo = c.String(),
                        serviceDate = c.DateTime(nullable: false),
                        noteSubjective = c.String(),
                        noteObjective = c.String(),
                        noteAssessment = c.String(),
                        notePlan = c.String(),
                    })
                .PrimaryKey(t => t.recordId)
                .ForeignKey("dbo.Departments", t => t.departmentId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentSources", t => t.sourceId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypes", t => t.documentId, cascadeDelete: true)
                .ForeignKey("dbo.Facilities", t => t.facilityId, cascadeDelete: true)
                .ForeignKey("dbo.InternalCaseNumbers", t => t.internalCaseId, cascadeDelete: true)
                .Index(t => t.internalCaseId)
                .Index(t => t.sourceId)
                .Index(t => t.departmentId)
                .Index(t => t.documentId)
                .Index(t => t.facilityId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userInternalId = c.Int(nullable: false),
                        userLastName = c.String(),
                        userFirstName = c.String(),
                        userLogin = c.String(),
                        userPassword = c.String(),
                        userRole = c.String(),
                        userSecurityQuestion = c.String(),
                        userSecurityAnswer = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.UserCaseNumberJunctions",
                c => new
                    {
                        userCaseNumberJunctionId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        caseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userCaseNumberJunctionId)
                .ForeignKey("dbo.CaseNumbers", t => t.caseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.caseId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCaseNumberJunctions", "userId", "dbo.Users");
            DropForeignKey("dbo.UserCaseNumberJunctions", "caseId", "dbo.CaseNumbers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Records", "internalCaseId", "dbo.InternalCaseNumbers");
            DropForeignKey("dbo.Records", "facilityId", "dbo.Facilities");
            DropForeignKey("dbo.Records", "documentId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Records", "sourceId", "dbo.DocumentSources");
            DropForeignKey("dbo.Records", "departmentId", "dbo.Departments");
            DropForeignKey("dbo.PrincipalCaseNumberJunctions", "principalId", "dbo.Principals");
            DropForeignKey("dbo.PrincipalCaseNumberJunctions", "caseId", "dbo.CaseNumbers");
            DropForeignKey("dbo.InternalCaseNumbers", "caseId", "dbo.CaseNumbers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserCaseNumberJunctions", new[] { "caseId" });
            DropIndex("dbo.UserCaseNumberJunctions", new[] { "userId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Records", new[] { "facilityId" });
            DropIndex("dbo.Records", new[] { "documentId" });
            DropIndex("dbo.Records", new[] { "departmentId" });
            DropIndex("dbo.Records", new[] { "sourceId" });
            DropIndex("dbo.Records", new[] { "internalCaseId" });
            DropIndex("dbo.PrincipalCaseNumberJunctions", new[] { "caseId" });
            DropIndex("dbo.PrincipalCaseNumberJunctions", new[] { "principalId" });
            DropIndex("dbo.InternalCaseNumbers", new[] { "caseId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserCaseNumberJunctions");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Records");
            DropTable("dbo.PrincipalCaseNumberJunctions");
            DropTable("dbo.Principals");
            DropTable("dbo.InternalCaseNumbers");
            DropTable("dbo.Facilities");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.DocumentSources");
            DropTable("dbo.Departments");
            DropTable("dbo.CaseNumbers");
        }
    }
}
