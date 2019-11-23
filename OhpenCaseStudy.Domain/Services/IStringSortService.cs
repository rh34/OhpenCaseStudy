using System;
using System.Collections.Generic;
using System.Text;
using OhpenCaseStudy.Dtos.StringSort;

namespace OhpenCaseStudy.Domain.Services
{
    public interface IStringSortService
    {
        SortResult Sort(string text, SortEnum sortEnum);
    }
}
