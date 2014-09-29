namespace LightSpeedModelMigrations
{
    using System;
    using System.ComponentModel;
    using Mindscape.LightSpeed.Migrations;


    [Migration("20140903052059")]
    [Description("Lightspeed has created date and update date stuff use theirs")]
    public class UseLSCreatUpdateDate : Migration
    {

        public override void Up()
        {

            //this.RenameColumn("Users", "Created_Date", "CreatedOn");
            //this.RenameColumn("Users","Updated_Date","UpdatedOn");
            //this.ChangeColumn("Users", "Created_Date",ModelDataType.DateTime,false);

            this.DropColumn("Users", null, "Created_Date", false);
            this.DropColumn("Users", null, "Updated_Date", false);
            this.AddColumn("Users", null, "CreatedOn", ModelDataType.DateTime, false);
            this.AddColumn("Users", null, "UpdatedOn", ModelDataType.DateTime, false);
        }

        public override void Down()
        {
            //this.RenameColumn("Users", "CreatedOn", "Created_Date");
            //this.RenameColumn("Users", "UpdatedOn", "Updated_Date");


            this.AddColumn("Users", null, "Created_Date", ModelDataType.DateTime, true);
            this.AddColumn("Users", null, "Updated_Date", ModelDataType.DateTime, true);
            this.DropColumn("Users", null, "CreatedOn", false);
            this.DropColumn("Users", null, "UpdatedOn", false);
        }
    }
}
