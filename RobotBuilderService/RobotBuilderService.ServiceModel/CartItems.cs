using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace RobotBuilderService.ServiceModel
{
    [Route("/api/cartitems", "GET")]
    public class CartItems : IReturn<CartItemsResponse>
    {
    }

    public class CartItemsResponse
    {
        public object CartItems { get; set; }
    }
}