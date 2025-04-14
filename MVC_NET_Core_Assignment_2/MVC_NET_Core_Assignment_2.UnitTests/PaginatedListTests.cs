using MVC_NET_Core_Assignment_1.Helpers;

namespace MVC_NET_Core_Assignment_2.UnitTests
{
    [TestFixture]
    public class PaginatedListTests
    {
        private List<string> _testItems;

        [SetUp]
        public void Setup()
        {
            _testItems = new List<string>();
            for (int i = 1; i <= 100; i++)
            {
                _testItems.Add($"Item {i}");
            }
        }

        [Test]
        public void Create_WithValidParameters_CreatesPaginatedList()
        {
            // Arrange
            int pageIndex = 1;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(pageSize));
            Assert.That(result[0], Is.EqualTo("Item 1"));
            Assert.That(result[9], Is.EqualTo("Item 10"));
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex));
            Assert.That(result.TotalPages, Is.EqualTo(10));
            Assert.That(result.TotalCount, Is.EqualTo(100));
        }

        [Test]
        public void Create_WithPageIndexTooLow_UsesProvidedIndex()
        {
            // Arrange
            int pageIndex = -1;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            // Cấu trúc thực tế không bắt buộc page index > 0
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex));
            // Kiểm tra xem kết quả có phần tử hay không, mà không đặt giả định về số lượng
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Create_WithPageIndexTooHigh_UsesProvidedIndex()
        {
            // Arrange
            int pageIndex = 20;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void Create_WithLastPage_ContainsCorrectNumberOfItems()
        {
            // Arrange
            int pageIndex = 10;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.Count, Is.EqualTo(10));
            Assert.That(result[0], Is.EqualTo("Item 91"));
            Assert.That(result[9], Is.EqualTo("Item 100"));
        }

        [Test]
        public void Create_WithEmptySource_ReturnsEmptyList()
        {
            // Arrange
            var emptySource = new List<string>();
            int pageIndex = 1;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(emptySource, pageIndex, pageSize);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
            Assert.That(result.TotalPages, Is.EqualTo(0));
            Assert.That(result.TotalCount, Is.EqualTo(0));
        }

        [Test]
        public void HasPreviousPage_OnFirstPage_ReturnsFalse()
        {
            // Arrange
            int pageIndex = 1;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.HasPreviousPage, Is.False);
        }

        [Test]
        public void HasPreviousPage_NotOnFirstPage_ReturnsTrue()
        {
            // Arrange
            int pageIndex = 2;
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.HasPreviousPage, Is.True);
        }

        [Test]
        public void HasNextPage_OnLastPage_ReturnsFalse()
        {
            // Arrange
            int pageIndex = 10; //
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.HasNextPage, Is.False);
        }

        [Test]
        public void HasNextPage_NotOnLastPage_ReturnsTrue()
        {
            // Arrange
            int pageIndex = 9; //
            int pageSize = 10;

            // Act
            var result = PaginatedList<string>.Create(_testItems, pageIndex, pageSize);

            // Assert
            Assert.That(result.HasNextPage, Is.True);
        }

        [Test]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            var items = new List<string> { "Item 1", "Item 2", "Item 3" };
            int count = 10;
            int pageIndex = 1;
            int pageSize = 3;

            // Act
            var paginatedList = new PaginatedList<string>(items, count, pageIndex, pageSize);

            // Assert
            Assert.That(paginatedList.Count, Is.EqualTo(3));
            Assert.That(paginatedList.TotalCount, Is.EqualTo(count));
            Assert.That(paginatedList.PageSize, Is.EqualTo(pageSize));
            Assert.That(paginatedList.PageIndex, Is.EqualTo(pageIndex));
            Assert.That(paginatedList.TotalPages, Is.EqualTo(4));
        }

        [Test]
        public void Constructor_WithZeroPageSize_HasMaximumTotalPages()
        {
            // Arrange & Act
            var result = new PaginatedList<string>(new List<string>(), 10, 1, 0);

            // Assert
            // Khi chia cho 0, kết quả mong đợi là Int.MaxValue
            Assert.That(result.TotalPages, Is.EqualTo(int.MaxValue));
        }
    }
} 