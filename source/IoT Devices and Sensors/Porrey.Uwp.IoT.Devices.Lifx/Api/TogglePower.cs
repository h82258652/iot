﻿// Copyright © 2015 Daniel Porrey. All Rights Reserved.
//
// This file is part of the IoT Devices and Sensors project.
// 
// IoT Devices and Sensors is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// IoT Devices and Sensors is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with IoT Devices and Sensors. If not, 
// see http://www.gnu.org/licenses/.
//
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Porrey.Uwp.IoT.Devices.Lifx
{
	public class TogglePower : ApiMethod<ApiResponse, Transition>
	{
		public TogglePower(ILifxIdentity identity)
			: base(identity, "lights/{0}/toggle", HttpMethod.Post)
		{
		}

		public async Task<ApiResponse> Set(ISelector selector, Transition transition)
		{
            return await this.Execute(transition, selector.GetSelectorText());
		}

		protected async override Task<ApiResponse> OnExecuted(HttpResponseMessage response)
		{
			ApiResponse returnValue = null;

			string json = await response.Content.ReadAsStringAsync();
			returnValue = JsonConvert.DeserializeObject<ApiResponse>(json);

			return returnValue;
		}
	}
}
