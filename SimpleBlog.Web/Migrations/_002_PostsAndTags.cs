﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Migrations
{
    [Migration(2)]
    public class _002_PostsAndTags : Migration
    {

        public override void Up()
        {
            Create.Table("posts")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id")
                .WithColumn("title").AsString(128)
                .WithColumn("slug").AsString(128)
                .WithColumn("created").AsDateTime()
                .WithColumn("updated").AsDateTime().Nullable()
                .WithColumn("deleted").AsDateTime().Nullable();

            Create.Table("tags")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("slug").AsString(128)
                .WithColumn("name").AsString(128);

            Create.Table("post_tags")
                .WithColumn("tag_id").AsInt32().ForeignKey("tags", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("post_id").AsInt32().ForeignKey("posts", "id").OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("post_tags");
            Delete.Table("posts");
            Delete.Table("tags");
        }
    }
}