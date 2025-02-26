﻿namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Represents the response returned after successfully creating a new saleItem.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created saleItem,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleItemResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created saleItem.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created saleItem in the system.</value>
    public Guid Id { get; set; }
}
