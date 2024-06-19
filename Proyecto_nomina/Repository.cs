﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using NominaAPI.Http.Responses;
using SharedModels.DTOs.User;

namespace Proyecto_nomina
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public Repository(HttpClient httpClient, string endpoint)
        {
            _endpoint = endpoint;
            _httpClient = httpClient;
        }

        public async Task<Response<T>> CreateAsync(object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<T>>(responseData);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Response<T>>(errorResponse);
                throw new Exception(jsonResponse.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Response<T>>(errorResponse);
                throw new Exception(jsonResponse.Message);
            }
        }

        public async Task<Response<IEnumerable<T>>> GetAllAsync(string? queryParams = null)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}?{queryParams}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<IEnumerable<T>>>(content);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Response<T>>(errorResponse);
                throw new Exception(jsonResponse.Message);
            }
        }

        public async Task<Response<T>> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<T>>(content);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Response<T>>(errorResponse);
                throw new Exception(jsonResponse.Message);
            }
        }

        public async Task<bool> UpdateAsync(int id, object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Response<T>>(errorResponse);
                throw new Exception(jsonResponse.Message);
            }
        }
    }
}
