namespace LightSpeedModelMigrations
{
  using System;
  using System.ComponentModel;
  using Mindscape.LightSpeed.Migrations;
  
  
  [Migration("20140902093553")]
  [Description("Starting point")]
  public class Vanila : Migration
  {
    
    public override void Up()
    {
      this.AddKeyTable("KeyTable", null, ModelDataType.Int32, 1);
    }
    
    public override void Down()
    {
    }
  }
}
