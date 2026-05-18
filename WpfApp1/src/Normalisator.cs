
using System;
using Newtonsoft.Json;

// De root van de JSON export
class DiscordExport
{
    [JsonProperty("guild")]
    public DiscordGuild? Guild { get; set; }

    [JsonProperty("channel")]
    public DiscordChannel? Channel { get; set; }

    [JsonProperty("exportedAt")]
    public DateTime ExportedAt { get; set; }

    [JsonProperty("messages")]
    public List<DiscordMessage> Messages { get; set; } = new();

    [JsonProperty("messageCount")]
    public int MessageCount { get; set; }
}

// De server/guild info
class DiscordGuild
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("iconUrl")]
    public string? IconUrl { get; set; }
}

// Het kanaal waar de berichten uit komen
class DiscordChannel
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
}

// Een enkel bericht
class DiscordMessage
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonProperty("timestampEdited")]
    public DateTime? TimestampEdited { get; set; }

    [JsonProperty("isPinned")]
    public bool IsPinned { get; set; }

    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("author")]
    public DiscordAuthor? Author { get; set; }

    [JsonProperty("attachments")]
    public List<DiscordAttachment> Attachments { get; set; } = new();

    [JsonProperty("embeds")]
    public List<DiscordEmbed> Embeds { get; set; } = new();

    [JsonProperty("stickers")]
    public List<DiscordSticker> Stickers { get; set; } = new();
}

// De auteur van een bericht
class DiscordAuthor
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("nickname")]
    public string? Nickname { get; set; }

    [JsonProperty("isBot")]
    public bool IsBot { get; set; }

    [JsonProperty("avatarUrl")]
    public string? AvatarUrl { get; set; }
}

// Een bijlage zoals een afbeelding of bestand
class DiscordAttachment
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("fileName")]
    public string? FileName { get; set; }

    [JsonProperty("fileSizeBytes")]
    public long FileSizeBytes { get; set; }
}

// Een embed zoals een GIF of link preview
class DiscordEmbed
{
    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("thumbnail")]
    public DiscordEmbedThumbnail? Thumbnail { get; set; }
}

// De thumbnail van een embed
class DiscordEmbedThumbnail
{
    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }
}

// Een sticker
class DiscordSticker
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("format")]
    public string? Format { get; set; }

    [JsonProperty("sourceUrl")]
    public string? SourceUrl { get; set; }
}