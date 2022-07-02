import { HttpHeadersKey } from './@types/Http';

type HttpClientConfig = {
  BaseUri?: string;
};

function ObjectHasKey(key: string, o: object): boolean {
  return key in o;
}

type HttpRequestConfig = {
  url?: string | URL;
  headers?: {
    [key: string | HttpHeadersKey]: string;
  };
};

export class HttpClient {
  private baseUri: URL;
  public readonly DefaultHeaders = new Headers();

  constructor() {}

  set BaseUri(uri: string) {
    this.baseUri = new URL(uri);
  }

  get BaseUri() {
    return this.baseUri?.origin;
  }

  private static convertToFullUrl(
    baseUri: string | URL,
    relative: string | URL
  ) {
    return new URL(relative, baseUri);
  }

  private getByString(uri: URL | string): Promise<Response> {
    const requestUri = this.generateRequestUri(uri);

    return fetch(requestUri.href);
  }

  private getByRequestConfig(config: HttpRequestConfig): Promise<Response> {
    const requestUri = this.generateRequestUri(config.url ?? '');
    return fetch(requestUri.href);
  }

  private generateRequestUri(uri: string | URL): URL {
    return this.baseUri === null
      ? new URL(uri)
      : HttpClient.convertToFullUrl(this.BaseUri, uri);
  }

  get(config: HttpRequestConfig): Promise<Response>;
  get(url: string | URL): Promise<Response>;
  get(config: string | URL | HttpRequestConfig): Promise<Response> {
    if (typeof config === 'string' || config instanceof URL) {
      return this.getByString(config);
    } else return this.getByRequestConfig(config);
  }
}

const client = new HttpClient();
// client.BaseUri = 'http://localhost:5189';
client.DefaultHeaders.append('Content-Type', 'application/json');
client.DefaultHeaders.append('authorization', localStorage.getItem('token')!);

client.get('http://localhost:5189/api/ViewPolicy');
