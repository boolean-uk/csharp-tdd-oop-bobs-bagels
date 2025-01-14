using exercise.core;

namespace exercise.tests;

public class RepositoryTest
{
    private IRepository _repo = LocalRepository.Default();

    [SetUp]
    public void SetUp()
    {
        _repo = LocalRepository.Default();
    }

    [Test]
    public void ContainsRegisteredItems()
    {
        Assert.That(_repo.getRegisteredItems().Count, Is.EqualTo(14));
    }

    [Test]
    public void ContainsDiscounts()
    {
        Assert.That(_repo.GetDiscountContainer().discounts.Count, Is.EqualTo(3));
    }

    [Test]
    public void CantAddDuplicateUser()
    {
        Assert.True(_repo.AddUser(new User { UserId = "test", priv = Privilege.Admin }));
        Assert.False(_repo.AddUser(new User { UserId = "test", priv = Privilege.Admin }));
    }
}
