namespace LightSpeedModelMigrations
{
  using System;
  using System.ComponentModel;
  using Mindscape.LightSpeed.Migrations;
  
  
  [Migration("20140904080032")]
  public class IncreasePhoneMaxSize : Migration
  {
    
    public override void Up()
    {
      this.ChangeColumn("Users", null, "Phone_number", ModelDataType.String, true, 50);
    }
    
    public override void Down()
    {
      this.ChangeColumn("Users", null, "Phone_number", ModelDataType.String, true, 20);
    }
  }
}
