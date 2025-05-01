using System;
using maschion.API.Data;
using maschion.API.Helpers.CQS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maschion.API.Features.LinkCustomerToSeller;

public class LinkCustomerToSellerCommandHandler(MaschionDbContext ctx) : ICommandAsync<LinkCustomerToSellerCommand>
{
    public async Task HandleAsync(LinkCustomerToSellerCommand command)
    {
        var seller = await ctx.Sellers.SingleAsync(x => x.ProfileId == command.sellerId);
        var customer = await ctx.Customers.SingleAsync(x => x.ProfileId == command.customerId);

        if (seller is not null && customer is not null)
        {
            customer.SellerId = seller.Id;
            await ctx.SaveChangesAsync();
        }

        await Task.CompletedTask;
    }
}
