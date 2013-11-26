using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace SimpleBlog.Web.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }

        public virtual string Title { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Content { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual DateTime? Updated { get; set; }
        public virtual DateTime? Deleted { get; set; }

        public virtual bool IsDeleted { get { return Deleted != null; } }

        public virtual IList<Tag> Tags { get; set; }
    }

    public class PostMap : ClassMapping<Post>
    {
        public PostMap()
        {
            Table("posts");

            Id(x => x.Id, x => x.Generator(Generators.Identity));

            ManyToOne(x => x.User, x =>
                {
                    x.Column("user_id");
                    x.NotNullable(true);
                });

            Property(x => x.Title, x => x.NotNullable(true));
            Property(x => x.Slug, x => x.NotNullable(true));
            Property(x => x.Content, x => x.NotNullable(true));

            Property(x => x.Created, x =>
                {
                    x.Column("created");
                    x.NotNullable(true);
                });

            Property(x => x.Deleted, x => x.Column("deleted"));

            Bag(x => x.Tags, x => 
                {
                    x.Key(y => y.Column("post_id"));
                    x.Table("post_tags");
                },x => x.ManyToMany(y => y.Column("tag_id")));
        }
    }
}