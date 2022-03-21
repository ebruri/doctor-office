        @foreach (Doctor doctor in @Model)
      {
        <th>@Html.ActionLink($"{doctor.Name}", "Details", new { id = doctor.DoctorId }, new { @class = "text-black"})</th>
          <th>
          @foreach(var speciality in @doctor.JoinEntities2)
          {
            <li>@speciality.speciality.Name
          }