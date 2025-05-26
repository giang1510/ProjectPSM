using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

/// <summary>
/// Represents photo data row for a product in database
/// </summary>
///
[Table("ProductPhotos")]
public class ProductPhoto : Photo { }
