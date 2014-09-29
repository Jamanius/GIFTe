namespace LightSpeedModelMigrations
{
    using System;
    using System.ComponentModel;
    using Mindscape.LightSpeed.Migrations;


    [Migration("20140904082057")]
    public class RenameUsersToCustomers : Migration
    {

        public override void Up()
        {

            this.RenameTable("Users", "Customers");
            //this.AddTable("Customers", null, new Field("Id", ModelDataType.Int32, false), new Field[] {
            //new Field("Name", ModelDataType.String, true).WithSize(50),
            //new Field("Phone_number", ModelDataType.String, true).WithSize(50),
            //new Field("Email", ModelDataType.String, true).WithSize(300),
            //new Field("CreatedOn", ModelDataType.DateTime, false),
            //new Field("UpdatedOn", ModelDataType.DateTime, false),
            //new Field("DeletedOn", ModelDataType.DateTime, true)});
            //this.DropTable("Users", null);
        }

        public override void Down()
        {
            this.RenameTable("Customers", "Users");
            //this.AddTable("Users", null, new Field("Id", ModelDataType.Int32, false), new Field[] {
            //new Field("Name", ModelDataType.String, true).WithSize(50),
            //new Field("Phone_number", ModelDataType.String, true).WithSize(50),
            //new Field("Email", ModelDataType.String, true).WithSize(300),
            //new Field("CreatedOn", ModelDataType.DateTime, false),
            //new Field("UpdatedOn", ModelDataType.DateTime, false),
            //new Field("DeletedOn", ModelDataType.DateTime, true)});
            //this.DropTable("Customers", null);
        }
    }
}
