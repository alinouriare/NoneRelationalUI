using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("tbl_Blog","aaa");
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired(false).HasColumnType("varchar");
            builder.HasIndex(c => c.Name).IsUnique(); 
            builder.Property(c => c.TypeBlog);

            builder.Property(c => c.VlueConversion).
                HasConversion(c => JsonConvert.SerializeObject(c),
               c=> JsonConvert.DeserializeObject<VlueConversion>(c));


            builder.Property(c => c.TypeBlog).HasConversion(c => c.ToString(),
                c =>(TypeBlog)Enum.Parse(typeof(TypeBlog),c));

            builder.Property(c => c.Name).HasField("BackingFieldName");
            builder.Property<int>("InsertBy");

            builder.Property<DateTime>("DateUpadte");

            //builder.Ignore(p => p.Person);  
        }
    }

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.MyCommentId);
        }
    }

    public class BLogWriterConfig : IEntityTypeConfiguration<BLogWriter>
    {
        public void Configure(EntityTypeBuilder<BLogWriter> builder)
        {
            builder.HasKey(c => new { c.BlogId, c.WriterId });
        }
    }
}
