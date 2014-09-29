namespace LightSpeedModelMigrations
{
    using System;
    using System.ComponentModel;
    using Mindscape.LightSpeed.Migrations;


    [Migration("20140902230851")]
    public class RubyStyleUserPropertyNames : Migration
    {

        public override void Up()
        {
            this.RenameColumn("Users", "Phone", "Phone_number");
            this.RenameColumn("Users", "CreatedDate", "Created_Date");
            this.RenameColumn("Users", "UpdatedDate", "Updated_Date");

            //this.DropColumn("Users", null, "Phone", false);
            //this.DropColumn("Users", null, "CreatedDate", false);
            //this.DropColumn("Users", null, "UpdatedDate", false);
            //this.AddColumn("Users", null, "Phone_number", ModelDataType.String, true, 20);
            //this.AddColumn("Users", null, "Created_Date", ModelDataType.DateTime, true);
            //this.AddColumn("Users", null, "Updated_Date", ModelDataType.DateTime, true);
        }

        public override void Down()
        {

            this.RenameColumn("Users", "Phone_number", "Phone");
            this.RenameColumn("Users", "Created_Date", "CreatedDate");
            this.RenameColumn("Users", "Updated_Date", "UpdatedDate");

            //this.DropColumn("Users", null, "Phone_number", false);
            //this.DropColumn("Users", null, "Created_Date", false);
            //this.DropColumn("Users", null, "Updated_Date", false);
            //this.AddColumn("Users", null, "Phone", ModelDataType.String, true, 20);
            //this.AddColumn("Users", null, "CreatedDate", ModelDataType.DateTime, true);
            //this.AddColumn("Users", null, "UpdatedDate", ModelDataType.DateTime, true);
        }
    }
}
