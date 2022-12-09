using System;
using System.Collections.Generic;

namespace IFS.DB.EF
{
    public partial class CardDetail
    {
        public CardDetail()
        {
            CardHolders = new HashSet<CardHolder>();
        }

        public int RecordId { get; set; }
        public string CardId { get; set; } = null!;
        public int AccountRecordId { get; set; }

        public virtual ICollection<CardHolder> CardHolders { get; set; }
    }
}
