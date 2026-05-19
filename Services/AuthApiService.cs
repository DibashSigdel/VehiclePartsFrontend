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

    public async Task<(List<StaffCustomerSearchResultDto> Results, string? Error)> SearchStaffCustomersAsync(
        string query,
        string token)
    {
        var url = $"api/staff/customers/search?q={Uri.EscapeDataString(query)}";
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return ([], await ReadErrorMessageAsync(response));
        }

        var results = await response.Content.ReadFromJsonAsync<List<StaffCustomerSearchResultDto>>() ?? [];
        return (results, null);
    }

    public async Task<StaffCustomerDetailDto?> GetStaffCustomerDetailAsync(int customerId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"api/staff/customers/{customerId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<StaffCustomerDetailDto>()
            : null;
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

    public async Task<StaffSendInvoiceEmailResponseDto?> SendStaffSalesInvoiceEmailAsync(int salesInvoiceId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"api/staff/sales-invoices/{salesInvoiceId}/send-email");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        var body = await response.Content.ReadFromJsonAsync<StaffSendInvoiceEmailResponseDto>();
        if (body is not null)
        {
            return body;
        }

        if (!response.IsSuccessStatusCode)
        {
            return new StaffSendInvoiceEmailResponseDto
            {
                SalesInvoiceId = salesInvoiceId,
                Sent = false,
                Message = "Could not send invoice email."
            };
        }

        return body;
    }

    public async Task<AdminFinancialReportDto?> GetAdminFinancialReportAsync(
        string period,
        string token,
        DateTime? from = null,
        DateTime? to = null)
    {
        var query = $"api/admin/reports/financial?period={Uri.EscapeDataString(period)}";
        if (from.HasValue)
        {
            query += $"&from={Uri.EscapeDataString(from.Value.ToString("O"))}";
        }

        if (to.HasValue)
        {
            query += $"&to={Uri.EscapeDataString(to.Value.ToString("O"))}";
        }

        using var request = new HttpRequestMessage(HttpMethod.Get, query);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<AdminFinancialReportDto>();
    }

    public async Task<StaffCustomerReportsDto?> GetStaffCustomerReportsAsync(string token, int limit = 20)
    {
        var query = $"api/staff/reports/customers?limit={limit}";
        using var request = new HttpRequestMessage(HttpMethod.Get, query);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<StaffCustomerReportsDto>();
    }

    public async Task<List<CustomerVehicleOptionDto>> GetCustomerVehiclesAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customer/portal/vehicles");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<CustomerVehicleOptionDto>>() ?? []
            : [];
    }

    public async Task<(CustomerVehicleOptionDto? Vehicle, string? Error)> CreateCustomerVehicleAsync(
        CustomerSaveVehicleRequestDto body,
        string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/customer/portal/vehicles")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return (null, await ReadErrorMessageAsync(response));
        }

        var vehicle = await response.Content.ReadFromJsonAsync<CustomerVehicleOptionDto>();
        return (vehicle, null);
    }

    public async Task<(CustomerVehicleOptionDto? Vehicle, string? Error)> UpdateCustomerVehicleAsync(
        int vehicleId,
        CustomerSaveVehicleRequestDto body,
        string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, $"api/customer/portal/vehicles/{vehicleId}")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return (null, await ReadErrorMessageAsync(response));
        }

        var vehicle = await response.Content.ReadFromJsonAsync<CustomerVehicleOptionDto>();
        return (vehicle, null);
    }

    public async Task<(bool Success, string? Error)> DeleteCustomerVehicleAsync(int vehicleId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/customer/portal/vehicles/{vehicleId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            return (false, await ReadErrorMessageAsync(response));
        }

        return (true, null);
    }

    private static async Task<string> ReadErrorMessageAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(body))
        {
            return response.ReasonPhrase ?? "Request failed.";
        }

        return body.Trim().Trim('"');
    }

    public async Task<List<CustomerAppointmentDto>> GetCustomerAppointmentsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customer/portal/appointments");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<CustomerAppointmentDto>>() ?? []
            : [];
    }

    public async Task<CustomerAppointmentDto?> BookCustomerAppointmentAsync(CustomerBookAppointmentRequestDto body, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/customer/portal/appointments")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<CustomerAppointmentDto>()
            : null;
    }

    public async Task<List<CustomerPartRequestDto>> GetCustomerPartRequestsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customer/portal/part-requests");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<CustomerPartRequestDto>>() ?? []
            : [];
    }

    public async Task<CustomerPartRequestDto?> CreateCustomerPartRequestAsync(CustomerCreatePartRequestDto body, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/customer/portal/part-requests")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<CustomerPartRequestDto>()
            : null;
    }

    public async Task<List<CustomerReviewDto>> GetCustomerReviewsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customer/portal/reviews");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<CustomerReviewDto>>() ?? []
            : [];
    }

    public async Task<List<CustomerReviewableAppointmentDto>> GetCustomerReviewableAppointmentsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/customer/portal/appointments/reviewable");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<CustomerReviewableAppointmentDto>>() ?? []
            : [];
    }

    public async Task<CustomerReviewDto?> SubmitCustomerReviewAsync(CustomerSubmitReviewRequestDto body, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/customer/portal/reviews")
        {
            Content = JsonContent.Create(body)
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<CustomerReviewDto>()
            : null;
    }

    public async Task<List<LowStockAlertDto>> GetAdminLowStockAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/system/low-stock");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<LowStockAlertDto>>() ?? []
            : [];
    }

    public async Task<List<AdminNotificationDto>> GetAdminNotificationsAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/admin/system/notifications");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<AdminNotificationDto>>() ?? []
            : [];
    }

    public async Task<SystemMonitoringRunDto?> RunAdminSystemChecksAsync(string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/system/run-checks");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<SystemMonitoringRunDto>()
            : null;
    }

    public async Task<bool> MarkAdminNotificationReadAsync(int notificationId, string token)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"api/admin/system/notifications/{notificationId}/read");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.SendAsync(request);
        return response.IsSuccessStatusCode;
    }
}