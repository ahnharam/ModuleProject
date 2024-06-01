using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleProject.Utils
{
    public class CacheManager : BindableBase
    {
        private static readonly Lazy<CacheManager> lazy = new Lazy<CacheManager>(() => new CacheManager());
        public static CacheManager Instance => lazy.Value;

        public CacheManager()
        {

        }
    }
}
