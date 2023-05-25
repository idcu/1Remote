﻿using System;
using _1RM.Service.Locality;
using Shawn.Utils;

namespace _1RM.Model
{
    public class TagFilter : NotifyPropertyChangedBase
    {
        public enum FilterTagsControlAction
        {
            AppendIncludedFilter,
            AppendExcludedFilter,
            Remove,
            Set,
        }
        public enum FilterType
        {
            Included,
            Excluded,
        }
        protected TagFilter(string tagName, FilterType type)
        {
            TagName = tagName;
            Type = type;
            IsExcluded = type == FilterType.Excluded;
        }

        public static TagFilter Create(string tagName, FilterType type)
        {
            return new TagFilter(tagName, type);
        }

        public readonly FilterType Type;

        public string TagName { get; }
        public bool IsExcluded { get; }
        public bool IsIncluded => !IsExcluded;


        public bool IsPinned => LocalityTagService.IsPinned(TagName);

        public void RaiseIsPinned()
        {
            RaisePropertyChanged(nameof(IsPinned));
        }

        public override string ToString()
        {
            throw new NotSupportedException();
        }
    }
}
