namespace Be.Vlaanderen.Basisregisters.Sqs.Responses;

public record ETagResponse(string Location, string ETag);