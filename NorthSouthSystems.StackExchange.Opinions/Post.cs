﻿#nullable disable
namespace NorthSouthSystems.StackExchange;

using MemoryPack;
using System.Xml.Linq;

[MemoryPackable]
public partial class Post
{
    [MemoryPackConstructor]
    private Post() { }

    internal Post(XElement xe)
    {
        Id = (int)xe.Attribute(nameof(Id));
        PostTypeId = (byte)(uint)xe.Attribute(nameof(PostTypeId));
        CreationDate = (DateTime)xe.Attribute(nameof(CreationDate));
        LastActivityDate = (DateTime)xe.Attribute(nameof(LastActivityDate));
        ViewCount = ((int?)xe.Attribute(nameof(ViewCount))).GetValueOrDefault();
        OwnerUserId = ((int?)xe.Attribute(nameof(OwnerUserId))).GetValueOrDefault(-1);
        Title = (string)xe.Attribute(nameof(Title));
        Tags = ((string)xe.Attribute(nameof(Tags)) ?? string.Empty).TrimStart('<').TrimEnd('>').Split(new[] { "><" }, StringSplitOptions.RemoveEmptyEntries);
        AnswerCount = ((int?)xe.Attribute(nameof(AnswerCount))).GetValueOrDefault();
        CommentCount = ((int?)xe.Attribute(nameof(CommentCount))).GetValueOrDefault();
        FavoriteCount = ((int?)xe.Attribute(nameof(FavoriteCount))).GetValueOrDefault();
    }

    public int Id { get; init; }
    public byte PostTypeId { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime LastActivityDate { get; init; }
    public int Score { get; init; }
    public int ViewCount { get; init; }
    public int OwnerUserId { get; init; }
    public string Title { get; init; }
    public IReadOnlyCollection<string> Tags { get; init; }
    public int AnswerCount { get; init; }
    public int CommentCount { get; init; }
    public int FavoriteCount { get; init; }
}