namespace LightSpeedModelMigrations
{
  using System;
  using System.ComponentModel;
  using Mindscape.LightSpeed.Migrations;
  
  
  [Migration("20140903045950")]
  [Description("Lightspeed has this built in so we can just use LS awesome")]
  public class RemoveManualSoftDelete : Migration
  {
    
    public override void Up()
    {
      this.DropColumn("Users", null, "Deleted", false);
      this.AddColumn("Users", null, "DeletedOn", ModelDataType.DateTime, true);
    }
    
    public override void Down()
    {
      this.AddColumn("Users", null, "Deleted", ModelDataType.Boolean, false);
      this.DropColumn("Users", null, "DeletedOn", false);
    }
  }
}
