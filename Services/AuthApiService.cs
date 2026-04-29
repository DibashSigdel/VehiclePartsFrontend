using System.Net.Http.Json;
using System.Net.Http.Headers;
using VehiclePartsFrontend.Models.Admin;
using VehiclePartsFrontend.Models.Auth;
using VehiclePartsFrontend.Models.Customer;
using VehiclePartsFrontend.Models.Staff;

namespace VehiclePartsFrontend.Services;

public class AuthApiService
{
    private readonly HttpClient _httpClient;

    public AuthApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<AuthResponseDto>();
    }

    public async Task<List<AdminUserDto>> GetAdminUsersAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/users");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var users = await response.Content.ReadFromJsonAsync<List<AdminUserDto>>();
        return users ?? [];
    }

    public async Task<bool> CreateUserByAdminAsync(AdminCreateUserRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/users")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateUserRoleAsync(int userId, string role, string token)
    {
        var requestModel = new AdminUpdateUserRoleRequestDto { Role = role };
        using var request = new HttpRequestMessage(HttpMethod.Put, $"api/admin/users/{userId}/role")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(int userId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/admin/users/{userId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<AdminVendorDto>> GetAdminVendorsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/vendors");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var vendors = await response.Content.ReadFromJsonAsync<List<AdminVendorDto>>();
        return vendors ?? [];
    }

    public async Task<bool> CreateVendorByAdminAsync(AdminCreateVendorRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/vendors")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateVendorAsync(int vendorId, AdminUpdateVendorRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"api/admin/vendors/{vendorId}")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteVendorAsync(int vendorId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/admin/vendors/{vendorId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<AdminPartDto>> GetAdminPartsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/parts");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var parts = await response.Content.ReadFromJsonAsync<List<AdminPartDto>>();
        return parts ?? [];
    }

    public async Task<List<AdminPartCategoryDto>> GetPartCategoriesAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/parts/categories");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var categories = await response.Content.ReadFromJsonAsync<List<AdminPartCategoryDto>>();
        return categories ?? [];
    }

    public async Task<bool> CreatePartByAdminAsync(AdminCreatePartRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/parts")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePartAsync(int partId, AdminUpdatePartRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"api/admin/parts/{partId}")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePartAsync(int partId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/admin/parts/{partId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CreatePartCategoryAsync(AdminCreatePartCategoryRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/parts/categories")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdatePartCategoryAsync(int categoryId, string categoryName, string token)
    {
        var requestModel = new AdminUpdatePartCategoryRequestDto { CategoryName = categoryName };
        using var request = new HttpRequestMessage(HttpMethod.Put, $"api/admin/parts/categories/{categoryId}")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePartCategoryAsync(int categoryId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/admin/parts/categories/{categoryId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<StaffCustomerWithVehicleResponseDto?> RegisterCustomerWithVehicleByStaffAsync(StaffRegisterCustomerRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/staff/customers/register-with-vehicle")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<StaffCustomerWithVehicleResponseDto>();
    }

    public async Task<bool> RegisterCustomerSelfAsync(CustomerSelfRegisterRequestDto requestModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/customers/self-register", requestModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<CustomerProfileDto?> GetCustomerProfileAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customers/profile");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<CustomerProfileDto>();
    }

    public async Task<bool> UpdateCustomerProfileAsync(CustomerUpdateProfileRequestDto requestModel, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, "api/customers/profile")
        {
            Content = JsonContent.Create(requestModel)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<AdminPurchaseInvoiceListItemDto>> GetAdminPurchaseInvoicesAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/purchase-invoices");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return await response.Content.ReadFromJsonAsync<List<AdminPurchaseInvoiceListItemDto>>() ?? [];
    }

    public async Task<AdminPurchaseInvoiceResponseDto?> CreateAdminPurchaseInvoiceAsync(AdminCreatePurchaseInvoiceRequestDto body, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/purchase-invoices")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<AdminPurchaseInvoiceResponseDto>();
    }

    public async Task<List<StaffCustomerOptionDto>> GetStaffSalesCustomersAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/staff/sales-invoices/customers");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return await response.Content.ReadFromJsonAsync<List<StaffCustomerOptionDto>>() ?? [];
    }

    public async Task<List<StaffPartSaleOptionDto>> GetStaffSalesPartsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/staff/sales-invoices/parts");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return await response.Content.ReadFromJsonAsync<List<StaffPartSaleOptionDto>>() ?? [];
    }

    public async Task<List<StaffSalesInvoiceListItemDto>> GetStaffSalesInvoicesAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/staff/sales-invoices");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return await response.Content.ReadFromJsonAsync<List<StaffSalesInvoiceListItemDto>>() ?? [];
    }

    public async Task<StaffSalesInvoiceResponseDto?> CreateStaffSalesInvoiceAsync(StaffCreateSalesInvoiceRequestDto body, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/staff/sales-invoices")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<StaffSalesInvoiceResponseDto>();
    }
}
