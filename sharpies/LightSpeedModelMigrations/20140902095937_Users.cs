namespace LightSpeedModelMigrations
{
  using System;
  using System.ComponentModel;
  using Mindscape.LightSpeed.Migrations;
  
  
  [Migration("20140902095937")]
  [Description("Adding new users table")]
  public class Users : Migration
  {
    
    public override void Up()
    {
      this.AddTable("Users", null, new Field("Id", ModelDataType.Int32, false), new Field[] {
            new Field("Name", ModelDataType.String, true).WithSize(50),
            new Field("Phone", ModelDataType.String, true).WithSize(20),
            new Field("Email", ModelDataType.String, true).WithSize(300),
            new Field("CreatedDate", ModelDataType.DateTime, true),
            new Field("UpdatedDate", ModelDataType.DateTime, true),
            new Field("Deleted", ModelDataType.Boolean, false)});
    }
    
    public override void Down()
    {
      this.DropTable("Users", null);
    }
  }
}
