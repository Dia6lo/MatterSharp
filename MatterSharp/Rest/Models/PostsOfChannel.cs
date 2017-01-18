using System.Collections.Generic;

namespace MatterSharp.Rest.Models
{
    public class PostsOfChannel
    {
        public List<string> Order { get; set; }

        public Dictionary<string, Post> Posts { get; set; }
    }
}