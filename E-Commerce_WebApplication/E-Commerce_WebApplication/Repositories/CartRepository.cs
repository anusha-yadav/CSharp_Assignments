using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebApplication.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ECommerceContext _context;

        public CartRepository(ECommerceContext context)
        {
            _context = context;
        }

        public Cart GetCartFromCurrentUser(int userId)
        {
            return _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Products)
                .FirstOrDefault(c => c.UserId == userId);
        }


        public void AddOrUpdateCartItem(int userId, int productId, int quantity)
        {
            var userCart = GetCartFromCurrentUser(userId);

            if (userCart == null)
            {
                userCart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                _context.Carts.Add(userCart);
            }

            var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductsId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // If the product is not in the cart, create a new CartItem
                var newCartItem = new CartItem
                {
                    ProductsId = productId,
                    Quantity = quantity
                };
                userCart.CartItems.Add(newCartItem);
            }

            _context.SaveChanges();
        }

        public Cart GetCartByUserId(int userid)
        {
            return _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefault(c => c.UserId == userid);
        }

        public void RemoveCartItem(int cartId, int cartItemId)
        {
            var userCart = GetCartFromCurrentUser(cartId);

            if (userCart != null)
            {
                var cartItemToRemove = userCart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId);

                if (cartItemToRemove != null)
                {
                    userCart.CartItems.Remove(cartItemToRemove);
                    _context.SaveChanges();
                }
            }
        }

        public int GetCartItemsCountByUserId(int userid)
        {
            return _context.Carts
                .Where(user => user.UserId == userid)
                .SelectMany(cart => cart.CartItems).Count();
        }

        public bool UpdateCartItemQuantity(Cart cart,int cartId, int quantity, int productId)
        {
            CartItem cartItemToUpdate = cart.CartItems.FirstOrDefault(item => item.CartID == cartId && item.ProductsId == productId);

            if (cartItemToUpdate != null)
            {
                cartItemToUpdate.Quantity = quantity;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

