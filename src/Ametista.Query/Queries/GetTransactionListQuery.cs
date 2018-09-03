﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ametista.Query.Queries
{
    public class GetTransactionListQuery : IQuery<IEnumerable<TransactionListQueryModel>>
    {
        public decimal Amount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime ChargeDate { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
