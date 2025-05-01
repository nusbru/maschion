using maschion.API.Helpers.CQS;

namespace maschion.API.Features.LinkCustomerToSeller;

public record LinkCustomerToSellerCommand(long customerId, long sellerId) : ICommand;