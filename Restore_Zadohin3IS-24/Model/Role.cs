//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restore_Zadohin3IS_24.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.Employee = new HashSet<Employee>();
        }
    
        public int id { get; set; }
        public string Post { get; set; }
    
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
