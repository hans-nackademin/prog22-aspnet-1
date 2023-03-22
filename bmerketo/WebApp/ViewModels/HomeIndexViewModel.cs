﻿using WebApp.Models;

namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public BestCollection BestCollection { get; set; } = null!;
        public CollectionItem[] UpToSell { get; set; } = null!;
        public IEnumerable<CollectionItem> TopSelling { get; set; } = null!;
    }
}
