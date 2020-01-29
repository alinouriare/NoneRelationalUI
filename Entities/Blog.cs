using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class VlueConversion
    {

        public string FirstName { get; set; }
    }

    public enum TypeBlog
    {
        type01,
        type02
    }

    [Table("tbl_Blog",Schema ="aaa")]
    public class Blog
    {
        public VlueConversion  VlueConversion { get; set; }

        public int BlogId { get; set; }

        //[Required]
        //[MaxLength(150, ErrorMessage = "")]
        //[Column(TypeName ="varchar")]

        private      string BackingFieldName { get; set; }


        public TypeBlog  TypeBlog { get; set; }
        public string Name { get; set; }

        ////[NotMapped]
        public Person Person { get; set; }


        public List<BLogWriter>  bLogWriters { get; set; }

    }

    public class BLogWriter
    {
        //[Key]
        //[Column(Order =1)]
        public int WriterId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int BlogId { get; set; }


        public Blog  Blog { get; set; }

        public Writer  Writer { get; set; }
    }
    [Table("tbl_Writer", Schema = "bbb")]
    public class Writer
    {
        public int WriterId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<BLogWriter> bLogWriters { get; set; }
    }


    public class Post
    {

        public int PostId { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
        public string Title { get; set; }

        public string Bodey { get; set; }

        public DateTime PublishDate { get; set; }

        public List<Comment> Comments { get; set; }



    }

    public class Comment
    {
        [Key]
        public int MyCommentId { get; set; }
    }
}
