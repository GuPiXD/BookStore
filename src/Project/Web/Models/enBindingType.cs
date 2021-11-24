namespace BookStore.Web.BookStore.Models
{

  /// <summary>
  /// Тип переплета
  /// </summary>
  public enum enBindingType
  {
    // Мягкий переплет
    GSB,           // Клеевое бесшвейное скрепление (Glued seamless bonding)
    BracketStaple, // Скрепление скобой (Bracket staple)
    // Твердый переплет
    SevenBC,       // 7БЦ
    SuperSevenBC,  // 7БЦ Супер обложка
  }
}
