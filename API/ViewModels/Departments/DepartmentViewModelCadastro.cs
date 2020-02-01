using API.ViewModels.Base;

namespace API.ViewModels.Departments
{
    public class DepartmentViewModelCadastro : EntityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
