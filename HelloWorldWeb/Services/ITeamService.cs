// <copyright file="ITeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(Member member);

        void DeleteTeamMember(Member member);

        TeamInfo GetTeamInfo();

        void EditTeamMember(int id, string name);
    }
}