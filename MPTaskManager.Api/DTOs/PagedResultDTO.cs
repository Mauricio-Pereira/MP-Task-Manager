﻿namespace MPTaskManager.Api.DTOs;

public class PagedResultDTO<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<T> Items { get; set; } = new List<T>();
}