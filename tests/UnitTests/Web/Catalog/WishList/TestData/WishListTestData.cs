using System;
using System.Collections;

namespace Microsoft.eShopWeb.UnitTests.Web.Catalog.WishList.TestData
{
    public class WishListTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new Object[] { 1 };
            yield return new Object[] { 1 };
            yield return new Object[] { 3 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

