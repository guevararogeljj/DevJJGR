﻿namespace DevJJGR.Presentation.Contracts.Members;

public sealed record RegisterMemberRequest(
    string Email,
    string FirstName,
    string LastName);
