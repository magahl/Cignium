using System;

namespace Cignium.AddressBooks
{
    public class SortOrderFactory
    {
        public static ContactSorter GetSorter(SortBy sortBy)
        {
            switch (sortBy)
            {
                case SortBy.FirstName:
                    return new FirstNameSorter();
                    break;
                case SortBy.LastName:
                    return new LastNameSorter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        } 
    }
}