namespace ManageCase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpdfparserandfilecontenttorecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "fileContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "fileContent");
        }
    }
}
