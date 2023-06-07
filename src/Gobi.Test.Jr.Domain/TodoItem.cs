using System.ComponentModel.DataAnnotations;

namespace Gobi.Test.Jr.Domain
{
    public class TodoItem
    {

        public int Id { get; set; }
        [Display(Name ="Completo")]
        public bool Completed { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Finalizado")]
        public bool Finished { get; set; }


    }
}