using StayConfirmed.DataAccess.Enums;

namespace StayConfirmed.BusinessLogic.Models.Stakeholder;

public class GetAllStakeholderResponseModel
{
    public int IdStakeholder { get; set; }
    public string Name { get; set; }
    public string Vat { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string Region { get; set; }
    public string Province { get; set; }
    public StakeholderType StakeholderType { get; set; }

    public static IEnumerable<GetAllStakeholderResponseModel> Convert(IEnumerable<DataAccess.Entities.Stakeholder> stakeholders)
    {
        List<GetAllStakeholderResponseModel> stakeholderResponseModels = [];
        foreach (var stakeholder in stakeholders)
        {
            stakeholderResponseModels.Add(new GetAllStakeholderResponseModel
            {
                IdStakeholder = stakeholder.IdStakeholder,
                Name = stakeholder.Name,
                Vat = stakeholder.Vat,
                Email = stakeholder.Email,
                Phone = stakeholder.Phone,
                Address = stakeholder.Address,
                City = stakeholder.City,
                Zip = stakeholder.Zip,
                Region = stakeholder.Region,
                Province = stakeholder.Province,
                StakeholderType = stakeholder.StakeholderType,
            });
        }

        return stakeholderResponseModels;
    }
}