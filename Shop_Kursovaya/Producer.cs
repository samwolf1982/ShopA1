//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop_Kursovaya
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producer
    {
        public Producer()
        {
            this.ProductProducer = new HashSet<ProductProducer>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ProductProducer> ProductProducer { get; set; }
    }
}
