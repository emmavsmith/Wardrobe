namespace Wardrobe.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Baseline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SourceBytes = c.Binary(nullable: false),
                        ContentType = c.String(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImageId = c.Long(),
                        Category = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                        OutfitItem_ItemId = c.Long(),
                        OutfitItem_OutfitId = c.Long(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemImage", t => t.ImageId)
                .ForeignKey("dbo.OutfitItem", t => new { t.OutfitItem_ItemId, t.OutfitItem_OutfitId })
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ImageId)
                .Index(t => t.UserId)
                .Index(t => new { t.OutfitItem_ItemId, t.OutfitItem_OutfitId })
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OutfitItem",
                c => new
                    {
                        ItemId = c.Long(nullable: false),
                        OutfitId = c.Long(nullable: false),
                        Id = c.Long(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemId, t.OutfitId })
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Outfit", t => t.OutfitId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.OutfitId);
            
            CreateTable(
                "dbo.Outfit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImageId = c.Long(),
                        UserId = c.Long(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                        User_Id = c.Long(),
                        OutfitItem_ItemId = c.Long(),
                        OutfitItem_OutfitId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OfferImage", t => t.ImageId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.OutfitItem", t => new { t.OutfitItem_ItemId, t.OutfitItem_OutfitId })
                .Index(t => t.ImageId)
                .Index(t => t.UserId)
                .Index(t => t.User_Id)
                .Index(t => new { t.OutfitItem_ItemId, t.OutfitItem_OutfitId });
            
            CreateTable(
                "dbo.OfferImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SourceBytes = c.Binary(nullable: false),
                        ContentType = c.String(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        Token = c.String(maxLength: 64),
                        TokenExpiry = c.DateTime(),
                        PasswordKey = c.Binary(nullable: false),
                        PasswordSalt = c.Binary(nullable: false),
                        PasswordResetToken = c.String(),
                        PasswordResetExpiry = c.DateTime(),
                        PasscodeKey = c.Binary(),
                        PasscodeSalt = c.Binary(),
                        LastUpdated = c.DateTime(nullable: false),
                        LastUpdated1 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "UserId", "dbo.User");
            DropForeignKey("dbo.Outfit", new[] { "OutfitItem_ItemId", "OutfitItem_OutfitId" }, "dbo.OutfitItem");
            DropForeignKey("dbo.Outfit", "UserId", "dbo.User");
            DropForeignKey("dbo.Outfit", "User_Id", "dbo.User");
            DropForeignKey("dbo.Item", "User_Id", "dbo.User");
            DropForeignKey("dbo.OutfitItem", "OutfitId", "dbo.Outfit");
            DropForeignKey("dbo.Outfit", "ImageId", "dbo.OfferImage");
            DropForeignKey("dbo.Item", new[] { "OutfitItem_ItemId", "OutfitItem_OutfitId" }, "dbo.OutfitItem");
            DropForeignKey("dbo.OutfitItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "ImageId", "dbo.ItemImage");
            DropIndex("dbo.Outfit", new[] { "OutfitItem_ItemId", "OutfitItem_OutfitId" });
            DropIndex("dbo.Outfit", new[] { "User_Id" });
            DropIndex("dbo.Outfit", new[] { "UserId" });
            DropIndex("dbo.Outfit", new[] { "ImageId" });
            DropIndex("dbo.OutfitItem", new[] { "OutfitId" });
            DropIndex("dbo.OutfitItem", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "User_Id" });
            DropIndex("dbo.Item", new[] { "OutfitItem_ItemId", "OutfitItem_OutfitId" });
            DropIndex("dbo.Item", new[] { "UserId" });
            DropIndex("dbo.Item", new[] { "ImageId" });
            DropTable("dbo.User");
            DropTable("dbo.OfferImage");
            DropTable("dbo.Outfit");
            DropTable("dbo.OutfitItem");
            DropTable("dbo.Item");
            DropTable("dbo.ItemImage");
        }
    }
}
