namespace LightSpeedModelMigrations
{
  using System;
  using System.ComponentModel;
  using Mindscape.LightSpeed.Migrations;
  
  
  [Migration("20140929055119")]
  [Description("giftDescription")]
  public class Add_basic_Gift_table : Migration
  {
    
    public override void Up()
    {
      this.AddTable("Notes", null, new Field("Id", ModelDataType.Int32, false), new Field[] {
            new Field("Text", ModelDataType.String, false),
            new Field("CreatedOn", ModelDataType.DateTime, false),
            new Field("UpdatedOn", ModelDataType.DateTime, false),
            new Field("DeletedOn", ModelDataType.DateTime, true),
            new ForeignKeyField("CustomerId", ModelDataType.Int32, false, "Customers", null, "Id")});
      this.AddTable("Gift", null, new Field("Id", ModelDataType.Int32, false), new Field[] {
            new Field("title", ModelDataType.String, false),
            new Field("description", ModelDataType.String, false),
            new Field("comments", ModelDataType.String, false),
            new Field("status", ModelDataType.String, false),
            new Field("CreatedOn", ModelDataType.DateTime, false),
            new Field("UpdatedOn", ModelDataType.DateTime, false),
            new Field("DeletedOn", ModelDataType.DateTime, true)});
    }
    
    public override void Down()
    {
      this.DropTable("Gift", null);
      this.DropTable("Notes", null);
    }
  }
}
