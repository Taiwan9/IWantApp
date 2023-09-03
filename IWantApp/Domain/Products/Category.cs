using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category() {}

    public Category(string name, string createdBy, string editedBy)
    {

        Name = name;
        Active = true;
        CreateBy = createdBy;
        EditedBy = editedBy;
        CreateOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();

    }

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsNotNullOrEmpty(CreateBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;
        Validate();
    }
}
