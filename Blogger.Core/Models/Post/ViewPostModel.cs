﻿using System;

namespace Blogger.Core.Models.Post
{
    public class ViewPostModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }
        public int Status { get; set; }
        public int StatusReason { get; set; }
    }
}
