using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public class ReceiptTransactionFacts : IFactProvider
    {
        private Receipt m_receipt;
        public ReceiptTransactionFacts(Receipt receipt)
        {
            m_receipt = receipt;
        }

        public List<Fact> Facts
        {
            get
            {
                List<Fact> facts = new List<Fact>();
                facts.Add(new Fact("Item", m_receipt.Item));
                facts.Add(new Fact("TransType", "PURREC"));
                return facts;
            }
        }
    }
}