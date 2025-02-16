# VectoRank Language Detection API 🏆🌍

VectoRank Language Detection is a free and open-source API that enables seamless language detection in applications. It provides an easy-to-use REST API powered by **ML.NET** using the **LbfgsMaximumEntropy** algorithm.

## 🚀 Features

- ✅ Supports **two language detection models**
- ✅ Easily switch models via `appsettings.json` (`ModelName` parameter)
- ✅ Lightweight & fast inference with **ML.NET**
- ✅ Simple API integration

## 🌐 Supported Languages

### 🔹 vectorank-ld-12 (9 languages)

- Mandarin Chinese
- English
- Spanish
- Russian
- Turkish
- German
- French
- Arabic
- Portuguese

### 🔹 vectorank-ld-37 (37 languages)

Includes all from `vectorank-ld-12`, plus:

- Japanese, Italian, Vietnamese, Dutch, Esperanto, Hebrew, Hungarian
- Greek, Finnish, Bulgarian, Swedish, Ukrainian, Czech, Polish, Latin
- Romanian, Serbian, Danish, Persian, Lithuanian, Macedonian
- Toki Pona, Interlingua, Klingon, Kabyle, Berber languages, Marathi
- Lingua Franca Nova

## ⚙️ Usage

### 🔧 Configuration

Set the `ModelName` parameter in `appsettings.json`:

```json
{
  "ModelName": "vectorank-ld-12"  // or "vectorank-ld-37"
}
```

## 📦 Docker Usage

### 🐳 Pull the image from Docker Hub:

```sh
docker pull vectorank/language-detection:latest
```

### ▶️ Run the container:

```sh
docker run -d -p 5000:8080 vectorank/language-detection
```

## 📡 API Integration

### 🔍 Detect Language

#### **Request:**

```sh
curl -X GET "http://localhost:5000/api/v1/language-detection/detect?text=your%20text%20content" -H "Content-Type: application/json"
```

#### **Response:**

```json
{
  "code": "tur",
  "language": "Turkish",
  "score": 0.74897593
}
```

## 📊 Model Performance Metrics

### **vectorank-ld-12 Metrics**

- **Macro Accuracy**: 0.9881
- **Micro Accuracy**: 0.9881
- **Top-K Prediction Count**: 0
- **Log Loss**: 0.0653
- **Log Loss Reduction**: 0.9703

### **vectorank-ld-37 Metrics**

- **Macro Accuracy**: 0.9722
- **Micro Accuracy**: 0.9722
- **Top-K Prediction Count**: 0
- **Log Loss**: 0.1320
- **Log Loss Reduction**: 0.9635

## 🔗 Links

- 🌍 **Website**: [vectorank.com](https://vectorank.com)
- 💻 **GitHub Repository**: [vectorank/language-detection](https://github.com/vectorank/language-detection)
- 🐳 **Docker Hub**: [vectorank/language-detection](https://hub.docker.com/r/vectorank/language-detection)
- 🧠 **Models**: [Model Files](https://github.com/vectorank/language-detection/tree/main/src/VectoRank.AI.NLP.LanguageDetection/VectoRank.AI.NLP.LanguageDetection.WebApp/Models)

For any questions or contributions, feel free to reach out! 🚀

