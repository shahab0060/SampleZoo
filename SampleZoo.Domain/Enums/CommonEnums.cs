using System.ComponentModel.DataAnnotations;

namespace SampleZoo.Domain.Enums
{
    #region Base Change Entity Result

    public enum BaseChangeEntityResult
    {
        Success,
        NotFound,
        Exists
    }

    #endregion

    #region Base Filter Entity Type

    public enum BaseFilterEntityType
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "حذف شده")]
        Deleted,
        [Display(Name = "حذف نشده")]
        NotDeleted
    }

    #endregion

    #region Base Sort Entity Type

    public enum BaseSortEntityType
    {
        [Display(Name = "پیش فرض")]
        Default,
        [Display(Name = "حذف نشده ")]
        NotDeleted,
        [Display(Name = "جدیدترین")]
        Newest,
        [Display(Name = "جدیدترین ویرایش")]
        LatestUpdate,
    }

    #endregion

    #region Base Site Sort Type

    public enum BaseSiteSortType
    {
        [Display(Name = "جدیدترین ها")]
        Newest,
        [Display(Name = "بهترین ها")]
        MostViewed,
    }

    #endregion

    #region sort type

    public enum SortType
    {
        Descending,
        Ascending,
    }

    #endregion
}
